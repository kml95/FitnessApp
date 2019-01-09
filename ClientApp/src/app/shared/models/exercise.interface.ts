export interface Exercise {
    name: string;
    stage: number;
    muscle: Muscle;
}

export enum Muscle {
    CHEST, BACK, LEGS, SHOULDERS, BICEPS, TRICEPS, ABS
}


