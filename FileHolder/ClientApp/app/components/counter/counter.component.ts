import { Component, OnInit } from '@angular/core';
import {DataService} from '../app/services/data.service';

const ALL_ITEMS_URL = 'https://localhost:59228/api/YourFiles';
@Component({
    selector: 'counter',
    templateUrl: './counter.component.html'
})
export class CounterComponent implements OnInit{
    
    constructor(private readonly dataService: DataService) {  }

    content: any;

    ngOnInit() {
        this.content = this.dataService.getData(ALL_ITEMS_URL);
        console.dir(this.content);
    }
}
