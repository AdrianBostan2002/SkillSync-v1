import { Component, ElementRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FileUploadEvent } from 'primeng/fileupload';
import { FileType } from '../../shared/enums/file-type';
import { ProjectService } from '../../services/project.service';
import { UploadedFile } from '../../shared/entities/models/uploaded-files';

@Component({
  selector: 'app-post-project-gallery',
  templateUrl: './post-project-gallery.component.html',
  styleUrl: './post-project-gallery.component.scss'
})
export class PostProjectGalleryComponent {
  galeryTitle: string = "Showcase Your Services In A Project Gallery";
  imageSubtitle: string = "Get Noticed by the right buyers with visual examples of your services";
  videoSubtitle_p1: string = "Capture buyers' attention with a video that showcases your service.";
  videoSubtitle_p2: string = "Please choose a video shorter than 75 seconds and smaller than 50MB"
  videoErrorMessage: string = "Your browser does not support the video tag.";
  documentSubtitle: string = "Show some of the best work you created in a document.";
  requiredActionMessage: string = "Upload at least one picture to go to next step";

  skillSubcategoryId?: string;
  jpegAndPngFileType: string = 'image/jpg, image/jpeg, image/png';
  videoFileType: string = 'video/mp4, video/quicktime';
  documentFileType: string = 'application/pdf, application/msword, application/vnd.openxmlformats-officedocument.wordprocessingml.document';
  emptyProfilePictureUrl = "assets/resources/upload-image.png";
  emptyUploadedVideoUrl: string = "assets/resources/upload-video.png";
  emptyUploadDocumentUrl = "assets/resources/upload-document.png";
  profilePictureUrl: string = "";
  file?: File;
  uploadFileType?: FileType;
  atLeastOnePictureUploaded: boolean = false;

  projectId?: string;

  uploadedPictures: UploadedFile[] = [{ url: this.emptyProfilePictureUrl }, { url: this.emptyProfilePictureUrl }, { url: this.emptyProfilePictureUrl }];
  uploadedVideo: UploadedFile = { url: this.emptyUploadedVideoUrl };
  uploadedDocuments: UploadedFile[] = [{ url: this.emptyUploadDocumentUrl }, { url: this.emptyUploadDocumentUrl }];

  initialPictures?: string[];
  initialVideo?: string;
  initialDocuments?: string[];

  async ngOnInit() {
    this.skillSubcategoryId = this.route.snapshot.params['id'];
    this.projectId = history.state.projectId;

    if (this.projectId) {
      let result = await this.projectService.getProjectGallery(this.projectId);

      this.initialPictures = [];
      result.pictures.forEach((picture, index) => {
        this.uploadedPictures[index].url = picture ?? this.emptyProfilePictureUrl;
        this.initialPictures?.push(picture);
        this.atLeastOnePictureUploaded = true;
      });

      this.uploadedVideo.url = result.video ?? this.emptyUploadedVideoUrl;
      this.initialVideo = result.video;

      this.initialDocuments = [];
      result.documents.forEach((document, index) => {
        this.uploadedDocuments[index].url = document ?? this.emptyUploadDocumentUrl;
        this.initialDocuments?.push(document);
      });
    }
  }

  constructor
    (
      private elRef: ElementRef,
      private route: ActivatedRoute,
      private router: Router,
      private projectService: ProjectService,
    ) { }

  private lastSelectedIndex: number = 0;

  triggerUploadPicture(index: number) {
    this.lastSelectedIndex = index;
    this.uploadFileType = FileType.Image;
    const nativeInputFile = this.elRef.nativeElement.querySelector('.upload-file-button input[type=file]');
    if (nativeInputFile) {
      nativeInputFile.click();
    }
  }

  triggerUploadVideo() {
    this.uploadFileType = FileType.Video;
    const nativeInputFile = this.elRef.nativeElement.querySelector('.upload-video-button input[type=file]');
    if (nativeInputFile) {
      nativeInputFile.click();
    }
  }

  triggerUploadDocument(index: number) {
    this.lastSelectedIndex = index;
    this.uploadFileType = FileType.Document;
    const nativeInputFile = this.elRef.nativeElement.querySelector('.upload-document-button input[type=file]');
    if (nativeInputFile) {
      nativeInputFile.click();
    }
  }

  selectedImage: string | null = null;

  uploadedFiles: File[] = [];

  async onUpload(event: FileUploadEvent) {
    let newFile: File = event.files[0];
    if (this.uploadFileType == FileType.Image) {
      this.uploadedPictures[this.lastSelectedIndex].url = URL.createObjectURL(newFile);
      this.uploadedPictures[this.lastSelectedIndex].file = newFile;
      this.atLeastOnePictureUploaded = true;
    }
    else if (this.uploadFileType == FileType.Video) {
      this.uploadedVideo.file = event.files[0];
      this.uploadedVideo.url = URL.createObjectURL(newFile);
    }
    else {
      this.uploadedDocuments[this.lastSelectedIndex].file = event.files[0];
      this.uploadedDocuments[this.lastSelectedIndex].url = URL.createObjectURL(event.files[0]);
    }
  }

  onPictureRemove(index: number) {
    this.uploadedPictures[index].url = this.emptyProfilePictureUrl;
    this.uploadedPictures[index].file = undefined;
    this.atLeastOnePictureUploaded = this.uploadedPictures.filter(picture => picture.url != this.emptyProfilePictureUrl).length != 0;
  }

  onVideoRemove() {
    this.uploadedVideo.url = this.emptyUploadedVideoUrl;
    this.uploadedVideo.file = undefined;
  }

  onDocumentRemove(index: number) {
    this.uploadedDocuments[index].url = this.emptyUploadDocumentUrl;
    this.uploadedDocuments[index].file = undefined;
  }

  navigateToPrev() {
    this.router.navigate(
      [`/post-project/description-faq/${this.skillSubcategoryId}`], { state: { projectId: this.projectId } }
    );
  }

  async navigateToNext() {
    let uploadedPictures: File[] = [];
    let unmodifiedMediaUrls: string[] = [];

    this.uploadedPictures.forEach((picture, index) => {
      if (picture.file !== undefined) {
        uploadedPictures.push(picture.file as File);
      }
      if (this.initialPictures && picture.url == this.initialPictures[index]) {
        unmodifiedMediaUrls.push(picture.url);
      }
    });

    let uploadedVideo: File | undefined = this.uploadedVideo.file;
    if (this.uploadedVideo.url == this.initialVideo) {
      unmodifiedMediaUrls.push(this.uploadedVideo.url);
    }

    let uploadedDocuments: File[] = [];

    this.uploadedDocuments.forEach((document, index) => {
      if (document.file !== undefined) {
        uploadedDocuments.push(document.file as File);
      }
      if (this.initialDocuments && document.url == this.initialDocuments[index]) {
        unmodifiedMediaUrls.push(document.url);
      }
    });

    if (this.projectId) {
      await this.projectService.putProjectGallery(this.projectId, uploadedPictures, uploadedVideo, uploadedDocuments, unmodifiedMediaUrls);
    }

    this.router.navigate([`/post-project/publish/${this.skillSubcategoryId}`], { state: { projectId: this.projectId } });
  }
}