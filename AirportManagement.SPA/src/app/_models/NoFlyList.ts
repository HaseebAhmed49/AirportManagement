import { Passangers } from "./Passangers";

export interface NoFlyList {
    Id: number;
    ActiveFrom: Date;
    ActiveDo: Date;
    NoFlyReason: string;
    CreatedAt: Date;
    UpdatedAt: Date;
    PassangerId: number;
    Passangers: Passangers;
}
