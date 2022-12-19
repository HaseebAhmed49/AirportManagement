import { Passangers } from "./Passangers";

export interface SecurityCheck {
    Id: number;
    CheckResult: string;
    Comments: string;
    CreatedAt: Date;
    UpdatedAt: Date;
    PassangerId: number;
    Passangers: Passangers;
}
