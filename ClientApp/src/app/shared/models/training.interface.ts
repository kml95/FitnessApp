import { Exercise } from './exercise.interface';

export interface Training {
    name: string;
    days: number;
    aim: TrainingAim;
    userName: string;
    exercises: Exercise [];
}

export enum TrainingAim {
    MASS, REDUCTION, STRENGTH
}
