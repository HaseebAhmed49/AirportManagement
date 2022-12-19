import { Airline } from "./airline";
import { Airport } from "./Airport";
import { FlightManifest } from "./FlightManifest";

export interface Flight {
    Id: number;
    DepartingGate: string;
    ArrivingGate: string;
    CreatedAt: Date;
    UpdatedAt: Date;
    ArrivingAirportId: number;
    ArrivingAirport: Airport;
    DepartureAirportId: number;
    DepartureAirport: Airport;
    AirlineId: number;
    Airline: Airline;
    FlightManifest: FlightManifest[];
}
