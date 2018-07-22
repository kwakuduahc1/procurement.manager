import { IContractParameters } from "./IContractParameters";
import { DateTime } from 'luxon';

export interface IContracts {
    contractsID: string;
    subject: string;
    methodsID: number;
    contractor: string;
    amount: number;
    isFlexible: boolean;
    isApproved: boolean;
    dateSigned: DateTime;
    isExecuted: boolean;
    expectedDate: DateTime;
    dateAdded: DateTime;
    concurrency: any[];
    contractParameters: IContractParameters[];
    count: number;
    percentage: number;
    source: number;
    sourcesID: string;
    itemsID: number;
    item: string;
    shortName: string;
}
