import { DateTime } from "luxon";

export interface IDefaultings {
    dateSigned: DateTime;
    contractsID: string;
    amount: number;
    expectedDate: DateTime;
    item: string;
    shortName: string;
    method: string;
    source: string;
    subject: string;
    progress: number;
}