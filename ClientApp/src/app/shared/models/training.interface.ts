import { Exercise } from './exercise.interface';

export interface Training {
    name: string;
    days: number;
    created: string;
    aim: TrainingAim;
    userName: string;
    exercises: Exercise [];
}

export enum TrainingAim {
    MASS, REDUCTION, STRENGTH
}
