import { IContracts } from "./IContracts";

export interface IMethods {
    methodsID: number;
    method: string;
    concurrency: any[];
    contracts: IContracts[];
}
