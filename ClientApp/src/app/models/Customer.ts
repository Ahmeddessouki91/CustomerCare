import { KeyValuePair } from './Customer';
export interface SaveCustomer {
    id: number,
    name: string,
    address: string,
    email: string,
    mobile: string,
    interactions: number,
    activated: boolean,
    jobId: number,
    governerateId: number,
    countryId: number,
    userId: number
}

export interface Customer {
    id: number,
    name: string,
    address: string,
    email: string,
    mobile: string,
    interactions: number,
    activated: boolean,
    country: KeyValuePair,
    governerate: KeyValuePair,
    job: KeyValuePair
}

export interface KeyValuePair {
    id: number,
    name: string
}

