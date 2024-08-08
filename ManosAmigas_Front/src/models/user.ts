export interface UserAuth {
    id: number;
    email: string;
    token: string;

}

export interface UserLogin {
    email: string;
    password: string;
}

export interface UserRegister {
    firstName: string;
    lastName: string;
    accountType: number;
    email: string;
    password: string;
}