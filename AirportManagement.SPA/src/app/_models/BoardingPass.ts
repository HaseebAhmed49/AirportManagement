import { Booking } from "./Booking";

export interface BoardingPass {
    Id: number;
    QRCode: string;
    CreatedAt: Date;
    UpdatedAt: Date;
    BookingId: number;
    Booking: Booking;
}
