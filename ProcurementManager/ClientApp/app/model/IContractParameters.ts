export interface IContractParameters {
    contractParametersID: number;
    contractParameter: string;
    contractsID: string;
    percentage: any;
    amount: number;
    isCompleted: boolean;
    expectedDate: Date;
    concurrency: number[];
    subject: string;
}
