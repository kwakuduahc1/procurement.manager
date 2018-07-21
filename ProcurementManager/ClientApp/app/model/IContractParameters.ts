import { DateTime } from "luxon";

export interface IContractParameters {
    contractParametersID: number;
    contractParameter: string;
    contractsID: string;
    percentage: any;
    amount: number;
    isCompleted: boolean;
    expectedDate: DateTime;
    concurrency: number[];
    subject: string;
}
