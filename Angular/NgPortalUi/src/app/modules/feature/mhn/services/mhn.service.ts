import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { HttpLocalClientService } from 'src/app/services/http-local-client.service';
import { MhnModule } from '../mhn.module';
import { MhnModels } from '../models/mhn.model';
@Injectable()
export class MhnService {
  constructor(private http: HttpLocalClientService) { }
  getCampaignList(data: any): Observable<any> {
    const url = 'api/MHN/GetAllCampaign';
    return this.http.getByQueryParams(url, data).pipe(map(res => this.extractCampaignListData(res)),
        catchError(handleError));;
}
//#endregion

//#region Private Methods
private extractData(res: any) {
    const data = res;
    return data.Search.slice(0, 3);
}
private extractDetailsData(res: any) {
    const data = {
        title: res.Title,
        year: res.Year,
        rated: res.Rated,
        released: res.Released
    };
    return data;
}
private extractCampaignListData(res: any) {
    let campaignList:MhnModels.ICampaignInfo[]=[]
    res.forEach(function (value: MhnModels.ICampaignInfo) {
        let data = {
            Name: value.Name,
            CampaignType: value.CampaignType,
            Option: value.Option,
            TotalDataCount: value.TotalDataCount,
            CreatedOn: value.CreatedOn
        }
        campaignList.push(data);
    });
    
    return campaignList;
}
//#endregion
}
export function handleError(error: Response | any) {
let errMsg: string = 'Error';
try {
    if (error instanceof Response) {
        const body: any = error.json() || '';
        const err = body.error || JSON.stringify(body);
        errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
    }
    else {
        errMsg = error.message ? error.message : error.toString();
    }
}
catch (e) {

}
return throwError(errMsg);
}
