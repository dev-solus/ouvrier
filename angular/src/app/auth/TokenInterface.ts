import { User } from '../Models';

export interface TokenInterface {
    user: User;
    token: string;
}
