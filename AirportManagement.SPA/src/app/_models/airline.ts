import { Flight } from "./Flight";

export interface Airline {
    Id: number;
    AirlineCode: number;
    AirlineName: string;
    AirlineCountry: string;
    CreatedAt: Date;
    UpdatedAt: Date;
    Flights: Flight[];
}