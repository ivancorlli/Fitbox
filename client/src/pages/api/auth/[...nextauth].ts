
import NextAuth, { AuthOptions } from "next-auth"
import GoogleProvider from "next-auth/providers/google"
import FacebookProvider from "next-auth/providers/facebook";



export const authOptions: AuthOptions = {
    secret: 'RANDOMDATA',
    providers: [
        GoogleProvider({
            clientId: '571704633649-9f2gubqi6bhi8ea2jsbr1r868s1bd9hh.apps.googleusercontent.com',
            clientSecret: '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'
        }),
        FacebookProvider({
            clientId: '709007244037124',
            clientSecret: '17bb4aa8f5c2ea7a3497950366e234ba'
        })
    ],
    pages: {
        signIn: '/auth/signin'
    }
}
export default NextAuth(authOptions)