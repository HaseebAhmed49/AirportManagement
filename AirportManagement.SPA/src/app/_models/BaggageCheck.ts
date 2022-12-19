import { Booking } from "./Booking";
import { Passangers } from "./Passangers";

export interface BaggageCheck {
    Id: number;
    CheckResult: string;
    CreatedAt: Date;
    UpdatedAt: Date;
    BookingId: number;
    Booking: Booking;
    PassangerId: number;
    Passangers: Passangers;
}
