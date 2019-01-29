export interface Product {
    name: string;
    calories: number;
    carbohydrates: number;
    protein: number;
    fat: number;
    category: ProductCategory;
}

export enum ProductCategory {
    CARBOHYDRATES, PROTEIN, FAT
}
