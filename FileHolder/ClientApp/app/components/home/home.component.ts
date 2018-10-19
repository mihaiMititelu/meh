import { Component } from '@angular/core';
import { UploadService } from '../app/services/upload.service';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['home.component.css']
})
export class HomeComponent {

    introText = "Welcome! This is an app for managing your files. Choose a file to upload, or modify one already present!\n Don't worry about saving, it's all done in the cloud...";
    headerText = "Whenever you're ready, click the Upload button below to get started:";

    constructor(private uploadService: UploadService) { }

    sendToServer(item: any) {
        this.uploadService.upload(item);
    }

    file: any;
    url: string = '';

    processImage(event: EventTarget) {

        const eventObj = event as MSInputMethodContext;
        const target = eventObj.target as HTMLInputElement;

        const files = target.files !== null ? target.files : [];

        if (target.files == null) {
            return;
        }

        this.file = files[0];
        this.previewImage(event);
    }

    onSendClick() {
        console.dir(this.file);
        this.sendToServer(this.file);
    }

    previewImage(event: any) {
        if (event.target.files && event.target.files[0]) {
            const reader = new FileReader();
            reader.onloadend = (e: any) => {
                this.url = e.target.result;
            };
            reader.readAsDataURL(event.target.files[0]);
        }
    }

}
