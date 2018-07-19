import { IContractParameters } from "./IContractParameters";

export interface IContracts {
    contractsID: string;
    subject: string;
    methodsID: number;
    contractor: string;
    amount: number;
    isFlexible: boolean;
    isApproved: boolean;
    dateSigned: Date;
    isExecuted: boolean;
    expectedDate: Date;
    dateAdded: Date;
    concurrency: any[];
    contractParameters: IContractParameters[];
    count: number;
}
