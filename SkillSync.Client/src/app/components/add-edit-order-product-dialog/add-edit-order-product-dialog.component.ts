import { Component, ElementRef, EventEmitter, Input, Output, SimpleChanges, TemplateRef, ViewChild } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Media } from '../../shared/entities/models/media';
import { FileType } from '../../shared/enums/file-type';
import { checkIfDocumentIsWord, fileInputToOrderContentType, getAudioFileTypeRestrictions, getDocumentFileTypeRestrictions, getPictureFileTypeRestrictions, getRarFileTypeRestrictions, getVideoFileTypeRestrictions } from '../../shared/utils';
import { FileUpload, FileUploadEvent } from 'primeng/fileupload';
import { OrderContentService } from '../../services/order-content.service';
import { UploadedFile } from '../../shared/entities/models/uploaded-files';
import { OrderContent } from '../../shared/entities/models/order-content';

@Component({
  selector: 'app-add-edit-order-product-dialog',
  templateUrl: './add-edit-order-product-dialog.component.html',
  styleUrl: './add-edit-order-product-dialog.component.css'
})
export class AddEditOrderProductDialogComponent {
  @Input() isDialogVisible!: boolean;
  @Input() orderContent?: OrderContent;
  @Input() fileType?: FileType;

  @Output() closeDialog = new EventEmitter<void>();
  @Output() orderContentModified = new EventEmitter<OrderContent>();

  @ViewChild('fileUpload') fileUpload?: FileUpload;

  media: Media[] = [];
  fileTypeRestrictions?: string;
  isLoading: boolean = false;

  documentFileType: FileType = FileType.Document;

  constructor(private formBuilder: FormBuilder, private elRef: ElementRef, private orderContentService: OrderContentService) { }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['orderContent']) {
      this.mapMedia();
    }
  }

  triggerUpload() {
    this.setFileTypeRestrictions();

    setTimeout(() => {
      const nativeInputFile = this.elRef.nativeElement.querySelector('.upload-file-button input[type=file]');
      if (nativeInputFile) {
        nativeInputFile.click();
      }
    }, 50);
  }

  private setFileTypeRestrictions() {
    switch (this.fileType) {
      case FileType.Image:
        this.fileTypeRestrictions = getPictureFileTypeRestrictions();
        break;
      case FileType.Video:
        this.fileTypeRestrictions = getVideoFileTypeRestrictions();
        break;
      case FileType.Document:
        this.fileTypeRestrictions = getDocumentFileTypeRestrictions();
        break;
      case FileType.Audio:
        this.fileTypeRestrictions = getAudioFileTypeRestrictions();
        break;
      default:
        this.fileTypeRestrictions = '';
    }
  }

  onUpload(event: FileUploadEvent) {
    let newFile: File = event.files[0];
    this.media = [];
    let uploadedFile: Media = { url: URL.createObjectURL(newFile), fileType: this.fileType!, file: newFile };
    this.media.push(uploadedFile);
    this.uploadMediaForm.patchValue({
      media: uploadedFile
    })
    this.isLoading = false;
  }

  mapMedia() {
    if (this.orderContent) {
      this.media = [];
      let media: Media = { url: this.orderContent.content, fileType: this.fileType! };
      this.media.push(media);
      this.uploadMediaForm.patchValue({
        media: media,
        description: this.orderContent.description
      })
    }
  }

  uploadMediaForm = this.formBuilder.group({
    media: [null as unknown as UploadedFile, [Validators.required]],
    description: ['', Validators.required]
  });

  async onSave() {
    let description = this.uploadMediaForm.controls.description.value;
    let media = this.uploadMediaForm.controls.media.value;

    let orderContent: OrderContent = { content: '', description: undefined, file: undefined, blobName: undefined, id: '', type: this.fileInputToOrderContentType(this.fileType ?? FileType.Image) };
    if (this.orderContent) {
      orderContent = { id: this.orderContent?.id, type: this.orderContent.type, content: this.orderContent.content, blobName: this.orderContent.blobName, description: this.orderContent.description, file: this.orderContent.file };
    }

    let shouldEmitChange = false;

    if (description != undefined && description != this.orderContent?.description) {
      orderContent.description = description;
      shouldEmitChange = true;
    }

    if (media != null && this.orderContent?.content != media.url) {
      orderContent.content = media.url;
      orderContent.file = media.file;
      shouldEmitChange = true;
    }

    if (shouldEmitChange) {
      this.orderContentModified.emit(orderContent);
    }

    this.clearDialog();
    this.closeDialog.emit();
  }

  onCancel() {
    this.fileUpload?.clear();

    this.isLoading = false;
    this.clearDialog();
    this.closeDialog.emit();
  }

  clearDialog() {
    this.media = [];
    this.uploadMediaForm.reset();
  }

  @ViewChild('displaySlideShow') displaySlideShow!: TemplateRef<any>;
  @ViewChild('displayDocument') displayDocument!: TemplateRef<any>;
  @ViewChild('displayAudio') displayAudio!: TemplateRef<any>;
  getTemplateBasedFileType() {
    switch (this.fileType) {
      case FileType.Image:
        return this.displaySlideShow;
      case FileType.Video:
        return this.displaySlideShow;
      case FileType.Document:
        return this.displayDocument;
      case FileType.Audio:
        return this.displayAudio;
      default:
        return this.displaySlideShow;
    }
  }

  getStylesBasedOnFileType() {
    switch (this.fileType) {
      case FileType.Document:
      case FileType.Audio:
        return { 'padding': '3em' };
      default:
        return {};
    }
  }

  checkIfDocumentIsWord = checkIfDocumentIsWord;
  fileInputToOrderContentType = fileInputToOrderContentType;

  
}
