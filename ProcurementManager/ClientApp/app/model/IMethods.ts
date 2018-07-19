import { IContracts } from "./IContracts";

export interface Methods {
    methodsID: number;
    method: string;
    concurrency: any[];
    contracts: IContracts[];
}
