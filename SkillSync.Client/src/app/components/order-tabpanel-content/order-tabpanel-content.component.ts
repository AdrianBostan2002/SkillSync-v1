import { Component, EventEmitter, Input, Output, SimpleChanges } from '@angular/core';
import { OrderContent } from '../../shared/entities/models/order-content';
import { OrderContentType } from '../../shared/enums/order-content-type';
import { Media } from '../../shared/entities/models/media';
import { FileType } from '../../shared/enums/file-type';
import { RoleType } from '../../shared/enums/role-type';
import { MenuItem } from 'primeng/api';
import { checkIfDocumentIsWord, downloadBlob } from '../../shared/utils';
import { OrderContentFileDto } from '../../shared/entities/requests/order-content-file-dto';
import { OrderContentService } from '../../services/order-content.service';
import { OrderContentPurpose } from '../../shared/enums/order-content-purpose';
import { NotificationService } from '../../services/notification.service';
import { ModifiedDescriptionDto } from '../../shared/entities/requests/modified-description-dto';
import { OrderService } from '../../services/order.service';

@Component({
  selector: 'app-order-tabpanel-content',
  templateUrl: './order-tabpanel-content.component.html',
  styleUrl: './order-tabpanel-content.component.css'
})
export class OrderTabpanelContentComponent {
  @Input() orderId?: string;
  @Input() orderContentPurpose?: OrderContentPurpose;
  @Input() orderContents: OrderContent[] = [];
  @Input() editModeActive?: boolean;
  @Input() role?: RoleType;
  @Output() changeOrderStatus: EventEmitter<void> = new EventEmitter<void>();

  currentOrderContents: OrderContent[] = [];

  modifyOrderContent?: OrderContent;

  picturesMedia: Media[] = [];
  videosMedia: Media[] = [];
  documents: OrderContent[] = [];
  audios: OrderContent[] = [];
  text?: string;

  pictureIndex?: number;
  videoIndex?: number;
  selectedAudio?: OrderContent;
  selectedDocument?: OrderContent;

  pictureOptions: MenuItem[] | undefined;
  videoOptions: MenuItem[] | undefined;
  documentOptions: MenuItem[] | undefined;
  audioOptions: MenuItem[] | undefined;
  notesOptions: MenuItem[] | undefined;

  freelancerRole = RoleType.Freelancer;

  addOrEditDialogVisible: boolean = false;
  addOrEditTextVisible: boolean = false;

  imageFileType = FileType.Image;
  videoFileType = FileType.Video;
  documentFileType = FileType.Document;
  audioFileType = FileType.Audio;

  fileType: FileType = FileType.Image;

  constructor
    (
      private orderService: OrderService,
      private orderContentService: OrderContentService,
      private notificationService: NotificationService,
    ) { }

  ngOnInit() {
    if (this.role == this.freelancerRole) {
      this.setMediaOptions();
    }
    else {
      this.editModeActive = false;
    }
  }

  private setMediaOptions() {
    this.setPicturesOptions();
    this.setVideosOptions();
    this.setDocumentsOptions();
    this.setAudiosOptions();
    this.setNotesOptions();
  }

  private setVideosOptions() {
    this.videoOptions = [
      {
        icon: 'pi pi-pencil',
        command: () => {
          this.editMedia(this.videosMedia, this.videoIndex!, FileType.Video);
        }
      },
      {
        icon: 'pi pi-trash',
        command: () => {
          this.videosMedia = this.deleteMedia(this.videosMedia, this.videoIndex!);
        }
      },
      {
        icon: 'pi pi-download',
        command: async () => {
          await this.downloadVideo();
        }
      }
    ];
  }

  public async downloadVideo() {
    if (this.videosMedia && this.videosMedia[this.videoIndex!]) {
      if (this.videosMedia[this.videoIndex!].url.includes("localhost")) {
        await this.downloadBlob(this.videosMedia[this.videoIndex!].url, this.videosMedia[this.videoIndex!].description ?? '');
      }
      else {
        let orderContent = this.currentOrderContents.find(content => content.content == this.videosMedia[this.videoIndex!].url);
        if (orderContent) {
          let videoFile = await this.orderContentService.getOrderContentFileById(orderContent.id);
          if (window) {
            const url = window.URL.createObjectURL(videoFile);
            await this.downloadBlob(url, this.videosMedia[this.videoIndex!].description ?? 'video');
          }
        }
      }
    }
  }

  private setPicturesOptions() {
    this.pictureOptions = [
      {
        icon: 'pi pi-pencil',
        command: () => {
          this.editMedia(this.picturesMedia, this.pictureIndex!, FileType.Image);
        }
      },
      {
        icon: 'pi pi-trash',
        command: () => {
          this.picturesMedia = this.deleteMedia(this.picturesMedia, this.pictureIndex!);
        }
      },
      {
        icon: 'pi pi-download',
        command: async () => {
          await this.downloadPicture();
        }
      },
    ];
  }

  public async downloadPicture() {
    if (this.picturesMedia && this.picturesMedia[this.pictureIndex!]?.url.includes("localhost")) {
      await this.downloadBlob(this.picturesMedia[this.pictureIndex!].url, this.picturesMedia[this.pictureIndex!].description ?? '');
    }
    else {
      let orderContent = this.currentOrderContents.find(content => content.content == this.picturesMedia[this.pictureIndex!].url);
      if (orderContent) {
        let pictureFile = await this.orderContentService.getOrderContentFileById(orderContent.id);
        if (window) {
          const url = window.URL.createObjectURL(pictureFile);
          await this.downloadBlob(url, this.picturesMedia[this.pictureIndex!].description ?? 'picture');
        }
      }
    }
  }

  private setAudiosOptions() {
    this.audioOptions = [
      {
        icon: 'pi pi-pencil',
        command: () => {
          this.modifyOrderContent = this.selectedAudio;
          this.fileType = FileType.Audio;
          this.addOrEditDialogVisible = true;
        }
      },
      {
        icon: 'pi pi-trash',
        command: () => {
          if (this.selectedAudio) {
            this.audios = this.audios.filter(audio => audio.content != this.selectedAudio?.content);
            this.currentOrderContents = this.currentOrderContents.filter(orderContent => orderContent.content != this.selectedAudio?.content)
          }
          else {
            this.notificationService.displayErrorMessage("Not any audio selected!");
          }
        }
      },
      {
        icon: 'pi pi-download',
        command: async () => {
          await this.downloadAudio();
        }
      }
    ];
  }

  async downloadAudio() {
    if (this.selectedAudio && this.selectedAudio.content.includes("localhost")) {
      await this.downloadBlob(this.selectedAudio.content, this.selectedAudio.blobName ?? '');
    }
    else {
      if (this.selectedAudio?.id) {
        let audioFile = await this.orderContentService.getOrderContentFileById(this.selectedAudio.id);
        if (window) {
          const url = window.URL.createObjectURL(audioFile);
          await this.downloadBlob(url, this.selectedAudio.description ?? 'audio');
        }
      }
    }
  }

  private setDocumentsOptions() {
    this.documentOptions = [
      {
        icon: 'pi pi-pencil',
        command: () => {
          this.modifyOrderContent = this.selectedDocument;
          this.fileType = FileType.Document;
          this.addOrEditDialogVisible = true;
        }
      },
      {
        icon: 'pi pi-trash',
        command: () => {
          if (this.selectedDocument) {
            this.documents = this.documents.filter(document => document.content != this.selectedDocument?.content);
            this.currentOrderContents = this.currentOrderContents.filter(orderContent => orderContent.content != this.selectedDocument?.content)
          }
          else {
            this.notificationService.displayErrorMessage("Not any document selected!");
          }
        }
      },
      {
        icon: 'pi pi-download',
        command: async () => {
          await this.downloadDocument();
        }
      },
    ];
  }

  async downloadDocument() {
    if (this.selectedDocument && this.selectedDocument.content.includes("localhost")) {
      await this.downloadBlob(this.selectedDocument.content, this.selectedDocument.blobName ?? '');
    }
    else {
      if (this.selectedDocument?.id) {
        let documentFile = await this.orderContentService.getOrderContentFileById(this.selectedDocument.id);
        if (window) {
          const url = window.URL.createObjectURL(documentFile);
          await this.downloadBlob(url, this.selectedDocument.description ?? 'document');
        }
      }
    }
  }

  private setNotesOptions() {
    this.notesOptions = [
      {
        icon: 'pi pi-pencil',
        command: () => {
          this.addOrEditTextVisible = true;
        }
      },
      {
        icon: 'pi pi-trash',
        command: () => {
          if (this.text) {
            this.text = undefined;
            this.removeTextContent();
            this.currentOrderContents = this.currentOrderContents.filter(content => content.type != OrderContentType.Text);
          }
        }
      },
    ];
  }

  get setAddMediaOptions() {
    return [
      {
        icon: 'pi pi-image',
        command: () => {
          this.addMediaButtonClick(FileType.Image);
        }
      },
      {
        icon: 'pi pi-video',
        command: () => {
          this.addMediaButtonClick(FileType.Video);
        },
        disabled: this.videosMedia.length > 0
      },
      {
        icon: 'pi pi-file',
        command: () => {
          this.addMediaButtonClick(FileType.Document);
        }
      },
      {
        icon: 'pi pi-volume-down',
        command: () => {
          this.addMediaButtonClick(FileType.Audio);
        }
      },
      {
        icon: 'pi pi-pencil',
        command: () => {
          if (this.text == undefined) {
            this.text = '';
          }
          this.addOrEditTextVisible = true;
        },
        disabled: this.text != undefined
      }
    ]
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['orderContents']) {
      this.mapOrderContents();
    }
  }

  mapOrderContents() {
    this.currentOrderContents = JSON.parse(JSON.stringify(this.orderContents));
    this.currentOrderContents.forEach(content => {
      this.processOrderContent(content);
    });
  }

  addMediaButtonClick(fileType: FileType) {
    this.modifyOrderContent = undefined;
    this.fileType = fileType;
    this.addOrEditDialogVisible = true;
  }

  orderContentModifiedEvent(orderContent: OrderContent) {
    if (orderContent.id != '') {
      let index = this.currentOrderContents.findIndex(content => content.id === orderContent.id);
      this.currentOrderContents[index].description = orderContent.description;
      if (orderContent.file) {
        this.currentOrderContents[index].content = orderContent.content;
        this.currentOrderContents[index].file = orderContent.file;
      }
      this.mediaUpdated(orderContent);
    } else {
      this.currentOrderContents.push(orderContent);
      this.processOrderContent(orderContent);
    }
    this.modifyOrderContent = undefined;
  }

  processOrderContent(orderContent: OrderContent) {
    switch (orderContent.type) {
      case OrderContentType.Image:
        let media: Media = { fileType: FileType.Image, url: orderContent.content, description: orderContent.description };
        this.picturesMedia.push(media);
        break;
      case OrderContentType.Video:
        let videoMedia: Media = { fileType: FileType.Video, url: orderContent.content, description: orderContent.description };
        this.videosMedia.push(videoMedia);
        break;
      case OrderContentType.Document:
        this.documents.push(orderContent);
        this.selectedDocument = orderContent;
        break;
      case OrderContentType.Audio:
        this.audios.push(orderContent);
        this.selectedAudio = orderContent;
        break;
      case OrderContentType.Text:
        this.setTextContent(orderContent.content);
        break;
    }
  }

  private setTextContent(content: string) {
    this.text = content;
    const tempDiv = document.createElement('text-content');
    tempDiv.innerHTML = content;

    const container = document.getElementById(`textContent${this.orderContentPurpose}`);
    if (container) {
      container.appendChild(tempDiv);
    }
  }

  private removeTextContent() {
    const container = document.getElementById(`textContent${this.orderContentPurpose}`);
    if (container) {
      const textContentElement = container.querySelector('text-content');
      if (textContentElement) {
        container.removeChild(textContentElement);
      }
    }
  }

  mediaUpdated(orderContent: OrderContent) {
    switch (orderContent.type) {
      case OrderContentType.Image:
        if (this.pictureIndex != undefined) {
          this.picturesMedia[this.pictureIndex].description = orderContent.description;
          if (orderContent.file) {
            this.picturesMedia[this.pictureIndex].url = orderContent.content;
          }
        }
        break;
      case OrderContentType.Video:
        if (this.videoIndex != undefined) {
          this.videosMedia[this.videoIndex].description = orderContent.description;
          if (orderContent.file) {
            this.videosMedia[this.videoIndex].url = orderContent.content;
          }
        }
        break;
      case OrderContentType.Document:
        if (this.selectedDocument) {
          this.selectedDocument.description = orderContent.description;
          if (orderContent.file) {
            this.selectedDocument.content = orderContent.content;
            this.selectedDocument.file = orderContent.file;
          }
        }
        break;
      case OrderContentType.Audio:
        if (this.selectedAudio) {
          this.selectedAudio.description = orderContent.description;
          if (orderContent.file) {
            this.selectedAudio.content = orderContent.content;
            this.selectedAudio.file = orderContent.file;
          }
        }
        break;
    }
  }

  pictureIndexChanged(newPictureIndex: number) {
    this.pictureIndex = newPictureIndex;
  }

  videoIndexChanged(newVideoIndex: number) {
    this.videoIndex = newVideoIndex;
  }

  uploadMedia(fileType: FileType) {
    this.modifyOrderContent = undefined;
    this.fileType = fileType;
    this.addOrEditDialogVisible = true;
  }

  editMedia(media: Media[], index: number, fileType: FileType) {
    if (media && media[index]) {
      this.modifyOrderContent = this.currentOrderContents.find(content => content.content === media[index].url);
      this.fileType = fileType;
      this.addOrEditDialogVisible = true;
    }
  }

  deleteMedia(media: Media[], index: number) {
    if (media && media[index]) {
      if (media.length == 1) {
        this.currentOrderContents = this.currentOrderContents.filter(content => content.content != media[index].url);
        media = [];
      }
      else if (media[index]) {
        let mediaElement = media[index];
        media = media.filter(media => media.url !== mediaElement.url);
        this.currentOrderContents = this.currentOrderContents.filter(content => content.content != mediaElement.url);
      }
    }
    return media;
  }

  textContentChanged(textContent: string) {
    this.text = textContent;
    this.removeTextContent();
    this.setTextContent(textContent);
    let orderContent = this.currentOrderContents.find(content => content.type == OrderContentType.Text);
    if (orderContent) {
      orderContent.content = textContent;
    }
    else {
      let orderContent: OrderContent = { content: textContent, description: undefined, file: undefined, blobName: undefined, id: '', type: OrderContentType.Text };
      this.currentOrderContents.push(orderContent);
    }
  }

  async onSave() {
    let uploadedPictures: OrderContentFileDto[] = [];
    let uploadedVideos: OrderContentFileDto[] = [];
    let uploadedDocuments: OrderContentFileDto[] = [];
    let uploadedAudios: OrderContentFileDto[] = [];
    let modifiedDescriptions: ModifiedDescriptionDto[] = [];
    let uploadedNotes: string = '';
    let deletedMedia: string[] = [];

    this.orderContents.forEach(orderContent => {
      if (!this.currentOrderContents.find(content => content.content == orderContent.content)) {
        deletedMedia.push(orderContent.id);
      }
    });

    this.currentOrderContents.forEach(orderContent => {
      let orderWithSameContent = this.orderContents.find(content => content.content == orderContent.content);

      if (orderContent.file) {
        switch (orderContent.type) {
          case OrderContentType.Image:
            uploadedPictures.push({ file: orderContent.file, description: orderContent.description });
            break;
          case OrderContentType.Video:
            uploadedVideos.push({ file: orderContent.file, description: orderContent.description });
            break;
          case OrderContentType.Document:
            uploadedDocuments.push({ file: orderContent.file, description: orderContent.description });
            break;
          case OrderContentType.Audio:
            uploadedAudios.push({ file: orderContent.file, description: orderContent.description });
            break;
        }
      }
      else if (orderContent.type == OrderContentType.Text) {
        uploadedNotes = orderContent.content;
      }
      else if (orderWithSameContent) {
        if (orderContent.description != orderWithSameContent.description) {
          modifiedDescriptions.push({ orderContentId: orderContent.id, description: orderContent.description });
        }
      }
    });

    if (this.orderId && this.orderContentPurpose != undefined) {
      await this.orderService.patchOrderContentMedia(uploadedPictures, uploadedVideos, uploadedDocuments, uploadedAudios, modifiedDescriptions, uploadedNotes, deletedMedia, this.orderId, this.orderContentPurpose);
      this.notificationService.displaySuccessMessage("Change made successfully!");

      if (this.orderContents.length == 0) {
        this.changeOrderStatus.emit();
      }
    }
  }

  checkIfDocumentIsWord = checkIfDocumentIsWord;
  downloadBlob = downloadBlob;
}