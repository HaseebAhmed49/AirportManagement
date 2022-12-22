import { Booking } from "./Booking";

export interface BoardingPass {
    Id: number;
    QRCode: string;
    CreatedAt: Date;
    UpdatedAt: Date;
    BookingId: number;
    Booking: Booking;
}

export interface BoardingPassForPassanger {
    qrCode: string,
    createdAt: Date;
    updatedAt: Date;
}