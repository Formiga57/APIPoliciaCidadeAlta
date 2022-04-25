import {client} from "../criminalCodeClient";

interface ICriminalCode {
    Id:number
}
interface ICriminalCodeFilter {
    Page:number
    Rows:number
    Way:boolean
    OrderId:number
    FilterId:number
    Filter:string
}

export const GetSortedCriminalCodes =({Page,Rows,Way,OrderId,FilterId,Filter}:ICriminalCodeFilter)=>{

}