import { Flight } from "./Flight";

export interface Airport {
    Id: number;
    AirportName: string;
    Country: string;
    State: string;
    City: string;
    CreatedAt: string;
    UpdatedAt: string;
    ArrivingFlights: Flight[];
    DepartureFlights: Flight[]
}
