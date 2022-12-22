import { Baggage, BaggageForPassanger } from "./Baggage";
import { BaggageCheck, BaggageCheckForPassanger } from "./BaggageCheck";
import { BoardingPass, BoardingPassForPassanger } from "./BoardingPass";
import { FlightManifest, FlightManifestForPassanger } from "./FlightManifest";
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


export interface BookingForPassanger{
    status: string;
    bookingPlatform: string;
    createdAt: Date;
    updatedAt: Date;
    baggageChecks: BaggageCheckForPassanger[];
    flightManifests: FlightManifestForPassanger[]
    boardingPasses: BoardingPassForPassanger[]
    baggages: BaggageForPassanger[]
}
