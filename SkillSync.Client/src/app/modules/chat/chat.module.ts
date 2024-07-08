import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ChatRoutingModule } from './chat-routing.module';
import { ChatPageComponent } from './chat.component';
import { InputGroupModule } from 'primeng/inputgroup';
import { AvatarModule } from 'primeng/avatar';
import { FormsModule } from '@angular/forms';
import { ImageModule } from 'primeng/image';
import { DocumentViewDialogComponent } from './document-view-dialog/document-view-dialog.component';
import { FileUploadModule } from 'primeng/fileupload';
import { DocumentViewComponent } from './document-view/document-view.component';
import { DialogModule } from 'primeng/dialog';
import { MessageService } from 'primeng/api';


@NgModule({
  declarations: [
    ChatPageComponent,
    DocumentViewDialogComponent,
  ],
  imports: [
    DocumentViewComponent,
    CommonModule,
    ChatRoutingModule,
    InputGroupModule,
    AvatarModule,
    FormsModule,
    ImageModule,
    FileUploadModule,
    DialogModule
  ],
  providers: [
    MessageService
  ]
})
export class ChatModule { }
