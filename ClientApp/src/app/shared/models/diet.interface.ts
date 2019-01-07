import { Meals } from './Meals.interface';

export interface Diet {
    dietName: string;
    mealsAmount: number;
    calories: number;
    userName: string;
    meals: Meals [];
}


