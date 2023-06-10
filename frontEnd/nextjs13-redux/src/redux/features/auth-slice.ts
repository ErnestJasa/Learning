import { createSlice, PayloadAction } from "@reduxjs/toolkit";

type InitialState = {
    value: AuthState;
}

type AuthState = {
    isAuth: boolean,
    username: string,
    uid: string,
    isModerator: boolean
}

const initialState = {
    value:{
        isAuth: false,
        username: "",
        uid: "",
        isModerator: false,
    } as AuthState,
} as InitialState

export const auth = createSlice({
    name: "auth",
    initialState,       // full version would be initialState: initialState, but since we're using the same name object, we can just leave it like that
    reducers:{
        logOut: ()=> {
            return initialState
        },
        logIn: (state, action:PayloadAction<string>)=>{
            return {
                value: {
                    isAuth: true,
                    username: action.payload,
                    uid: "rthevdsf",
                    isModerator: false,
                }
            }
        },
        toggleModerator: (state) => {
            state.value.isModerator = !state.value.isModerator;
        }
    }
})

export const {logIn, logOut, toggleModerator} = auth.actions
export default auth.reducer;