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

export interface SecurityCheckForPassanger {
    checkResult: string;
    comments: string;
    createdAt: Date;
    updatedAt: Date;
}

