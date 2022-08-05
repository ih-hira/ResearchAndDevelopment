import { Component, ElementRef, Input, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { MhnModels } from '../../../../models/mhn/mhn.model';
import { MhnService } from '../../../../services/mhn/mhn.service';
import { takeUntil } from 'rxjs/operators';
@Component({
    selector: 'app-mhn-campaign-list',
    templateUrl: './mhn-campaign-list.component.html',
    styleUrls: ['./mhn-campaign-list.component.css']
})
export class MhnCampaignListComponent implements OnInit {

    protected ngUnsubscribe$: Subject<void> = new Subject<void>();
    public DataStore: MhnModels.ICampaignInfo[] = [];
    public title:string;
    constructor(private _mhnService: MhnService) {
        //this.title = this.elementRef.nativeElement.getAttribute('title');
        
    }
    ngOnDestroy() {
        this.ngUnsubscribe$.next();
        this.ngUnsubscribe$.complete();
    }

    ngOnInit() {
        console.log(this.title);
        let queryParams: any = {
            currentPage: 1,
            pageSize: 20
        };
        this._mhnService.getCampaignList(queryParams).pipe(takeUntil(this.ngUnsubscribe$)).subscribe((res: MhnModels.ICampaignInfo[]) => {
            this.DataStore = res;
            console.log(this.DataStore);
        });
    }

}
