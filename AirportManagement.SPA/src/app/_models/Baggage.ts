import { Booking } from "./Booking";

export interface Baggage {
    Id: number;
    WeightInKG: number;
    CreatedDate: Date;
    UpdatedDate: Date;
    BookingId: number;
    Booking: Booking;
}

export interface BaggageForPassanger {
    weightInKG: number;
    createdDate: Date;
    updatedDate: Date;
}