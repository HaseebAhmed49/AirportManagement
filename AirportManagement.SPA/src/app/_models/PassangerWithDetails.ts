import { Observable } from "rxjs";
import { BookingForPassanger } from "./Booking";
import { NoFlyListForPassanger } from "./NoFlyList";
import { SecurityCheckForPassanger } from "./SecurityCheck";

export interface PassangerWithDetails {
    firstName: string;
    lastName: string;
    dateOfBirth: Date;
    countryOfCitizenship: string;
    countryOfResidence: string;
    passportNumber: string;
    createdAt: Date;
    updatedAt: Date;
    SecurityChecks: Observable<SecurityCheckForPassanger[]>;
    Bookings: BookingForPassanger[];
    NoFlyLists: NoFlyListForPassanger[];
}