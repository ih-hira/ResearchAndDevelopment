export class LocalStorageHelper{
    static getByKey(key:string){
        return localStorage.getItem(key);
    }
}