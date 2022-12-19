import { Baggage } from "./Baggage";
import { BaggageCheck } from "./BaggageCheck";
import { BoardingPass } from "./BoardingPass";
import { FlightManifest } from "./FlightManifest";
import { Passangers } from "./Passangers";

export interface Booking {
    Id: number;
    Status: string;
    BookingPlatform: string;
    CreatedAt: Date;
    UpdatedAt: Date;
    BaggageChecks: BaggageCheck[];
    FlightManifests: FlightManifest[];
    BoardingPass: BoardingPass[];
    Baggages: Baggage[]
    PassangerId: number;
    Passangers: Passangers;
}
