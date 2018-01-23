//import { Inject } from '@angular/core';
//import { Http, Response } from '@angular/http';
import { Component, Input, Injectable, Inject } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { InventoryMaster } from '../viewmodels/inventory';

//import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
//import 'rxjs/add/operator/catch';
//import { Observable } from 'rxjs/Rx';

//import { map, catchError } from 'rxjs/operators';

@Injectable()
export class HomeService {

    public Inventory: InventoryMaster[] = [];
    public bseUrl: string = "";

    //constructor(public http: Http, @Inject('BASE_URL') baseUrl: string) {
    constructor(public http: Http) {
        //this.bseUrl = baseUrl;
    }

    getInventoryList() {
        //return this.http.get(this.bseUrl + 'api/InventoryMasterAPI/Inventory')
        return this.http.get('api/InventoryMasterAPI/Inventory')
            .map(response => response.json());
            //.catch();
    }
}