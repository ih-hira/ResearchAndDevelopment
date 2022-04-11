import { Injectable } from "@angular/core";

@Injectable() 
export class Constants {
    public readonly GATEWAY: string = 'https://www.userdomain.com/';
    public static readonly API_BASE_URL: string = 'https://localhost:44320/';
    public readonly API_MOCK_ENDPOINT: string = 'https://www.userdomainmock.com/';
    public static TitleOfSite: string = " Making API calls the Right Way by Monica";
} 