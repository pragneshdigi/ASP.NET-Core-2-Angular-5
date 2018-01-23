import { Component, Input, Inject } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { HomeService } from './home.service';
import { InventoryMaster } from '../viewmodels/inventory';

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent {

    public Inventory: InventoryMaster[] = [];
    items: InventoryMaster[];

    AddTable: boolean = false;

    public sInventoryID: number = 0;
    public sItemName = "";
    public sStockQty: number = 0;
    public sReorderQty: number = 0;
    public sPriorityStatus: boolean = false;

    //public imgchk = require("./Images/chk.png");
    //public imgunChk = require("./Images/unchk.png");
    public imgchk = "";
    public imgunChk = "";

    public bseUrl: string = "";

    public schkName: string = "";
    myName: string;

    
    //constructor(public http: Http, @Inject('BASE_URL') baseUrl: string) {
    //constructor(public homeService: HomeService, public http: Http, @Inject('BASE_URL') baseUrl: string) {
    constructor(public homeService: HomeService, public http: Http) {
        this.myName = "Pragnesh";
        this.AddTable = false;
        //this.bseUrl = baseUrl;
        this.getData();
    }

    getData() {
        //var service = this.homeService.getInventoryList(this.bseUrl);
        //console.log('URL : ' + this.bseUrl);
        var service = this.homeService.getInventoryList();

        service.subscribe(result => {
            this.Inventory = result;            
        },
            error => console.error(error)
        );

        //this.http.get(this.bseUrl + 'api/InventoryMasterAPI/Inventory')
        //    .subscribe(result => {
        //        this.Inventory = result.json();
        //    },
        //    error => console.error(error)
        //    );
    }

    AddInventory()
    {
        this.AddTable = true;
        this.sInventoryID = 0;
        this.sItemName = "";
        this.sStockQty = 50;
        this.sReorderQty = 50;
        this.sPriorityStatus = false;
    }

    editInventoryDetails(inventoryIDs: number, itemNames: string, stockQtys: number, reorderQtys: number, priorityStatus: number) {
        this.AddTable = true;
        this.sInventoryID = inventoryIDs;
        this.sItemName = itemNames;
        this.sStockQty = stockQtys;
        this.sReorderQty = reorderQtys;

        if (priorityStatus == 0) {
            this.sPriorityStatus = false;
        }
        else {
            this.sPriorityStatus = true;
        }
    }

    addInventoryDetails(inventoryIDs: number, itemNames: string, stockQtys: number, reorderQtys: number, priorityStatus: boolean) {
        var pStatus: number = 0;

        this.schkName = priorityStatus.toString();
        if (this.schkName == "true") {
            pStatus = 1;
        }

        var headers = new Headers();
        headers.append('Content-Type', 'application/json; charset=utf-8');

        if (inventoryIDs == 0) {
            this.http.post(this.bseUrl + 'api/InventoryMasterAPI/', JSON.stringify({
                InventoryID: inventoryIDs, ItemName: itemNames, StockQty: stockQtys, ReorderQty: reorderQtys, PriorityStatus: pStatus
            }), 

                { headers: headers })
                .subscribe(response => {
                    this.getData();
                }, error => { }
                );
        }
        else {
            this.http.put(this.bseUrl + 'api/InventoryMasterAPI/' + inventoryIDs, JSON.stringify({
                InventoryID: inventoryIDs, ItemName: itemNames, StockQty: stockQtys, ReorderQty: reorderQtys, PriorityStatus: pStatus
            }),
                { headers: headers })
                .subscribe(response => {
                    this.getData();
                }, error => { }
                );
        }
        this.AddTable = false;
    }

    deleteinventoryDetails(inventoryIDs: number) {
        var headers = new Headers();
        headers.append('Content-Type', 'application/json; charset=utf-8');
        this.http.delete(this.bseUrl + 'api/InventoryMasterAPI/' + inventoryIDs, { headers: headers })
            .subscribe(response => {
                this.getData();
            },
            error => { }
            );
    }

    closeEdits() {        
            this.AddTable = true;
            this.sInventoryID = 0;
            this.sItemName = "";
            this.sStockQty = 50;
            this.sReorderQty = 50;
            this.sPriorityStatus = false;
        
    }
}

export interface InventoryMaster {
    inventoryId: number;
    itemName: string;
    stockQty: number;
    reOrderQty: number;
    priorityStatus: number;
}
