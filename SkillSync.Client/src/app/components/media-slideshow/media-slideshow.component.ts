import { Component, ElementRef, EventEmitter, Input, Output, SimpleChanges, ViewChild } from '@angular/core';
import { Media } from '../../shared/entities/models/media';
import { FileType } from '../../shared/enums/file-type';

@Component({
  selector: 'app-media-slideshow',
  templateUrl: './media-slideshow.component.html',
  styleUrl: './media-slideshow.component.css'
})
export class MediaSlideshowComponent {
  @Input() media?: Media[];
  @Output() slideShowIndexEvent = new EventEmitter<number>();

  slideShowIndex: number = 0;

  imageFileType = FileType.Image;
  videoFileType = FileType.Video;

  ngOnChanges(changes: SimpleChanges) {
    if (changes['media']) {
      this.slideShowIndex = 0;
      this.slideShowIndexEvent.emit(this.slideShowIndex);
    }
  }

  onNextMedia() {
    let lenght = this.media?.length;
    if (this.slideShowIndex == lenght! - 1) {
      this.slideShowIndex = 0;
    } else {
      this.slideShowIndex = (this.slideShowIndex + 1) % lenght!;
    }
    this.slideShowIndexEvent.emit(this.slideShowIndex);
  }

  onPreviousMedia() {
    let lenght = this.media?.length;
    if (this.slideShowIndex == 0) {
      this.slideShowIndex = (lenght! - 1);
      this.slideShowIndexEvent.emit(this.slideShowIndex);
      return;
    }
    this.slideShowIndex = (this.slideShowIndex - 1) % lenght!;
    this.slideShowIndexEvent.emit(this.slideShowIndex);
  }
}