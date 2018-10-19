import { Injectable } from "@angular/core";
import { Http, RequestOptions, Headers } from "@angular/http";

const UNIQUE_UPLOAD_URL = 'http://localhost:59288/api/Upload';

@Injectable()
export class UploadService {

    constructor(private http: Http) { }

    upload(item: any): Response {

        var result: any;

        this.http.post(UNIQUE_UPLOAD_URL,
            item,
            new RequestOptions({
                headers: new Headers({
                    'Content-Type': 'application/json'
                })
            })).subscribe(res => { result = res; }, err => { result = err; });

        return result;
    }
}