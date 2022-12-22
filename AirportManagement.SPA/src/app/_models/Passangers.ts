import { Booking } from "./Booking";
import { NoFlyList } from "./NoFlyList";
import { SecurityCheck } from "./SecurityCheck";

export interface Passangers {
    id: number;
    firstName: string;
    lastName: string;
    DateOfBirth: Date;
    CountryOfCitizenship: string;
    CountryOfResidence: string;
    passportNumber: string;
    CreatedAt: Date;
    UpdatedAt: Date;
    SecurityChecks: SecurityCheck[];
    Bookings: Booking[];
    NoFlyLists: NoFlyList[];
}
