import { Booking } from "./Booking";
import { Flight } from "./Flight";

export interface FlightManifest {
    Id: number;
    CreatedAt: Date;
    UpdatedAt: Date;
    FlightId: number;
    Flights: Flight;
    BookingId: number;
    Booking: Booking;
}
