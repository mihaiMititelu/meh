import { Injectable } from "@angular/core";
import { Http, RequestOptions, Headers } from "@angular/http";

@Injectable()
export class DataService {

    constructor(private http: Http) {  }

    getData(url: string) {
        this.http.get(url).subscribe(res => { return res.text(); });
    }
}