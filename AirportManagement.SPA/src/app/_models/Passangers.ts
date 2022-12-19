import { Booking } from "./Booking";
import { NoFlyList } from "./NoFlyList";
import { SecurityCheck } from "./SecurityCheck";

export interface Passangers {
    Id: number;
    FirstName: string;
    LastName: string;
    DateOfBirth: Date;
    CountryOfCitizenship: string;
    CountryOfResidence: string;
    PassportNumber: string;
    CreatedAt: Date;
    UpdatedAt: Date;
    SecurityChecks: SecurityCheck[];
    Bookings: Booking[];
    NoFlyLists: NoFlyList[];
}
