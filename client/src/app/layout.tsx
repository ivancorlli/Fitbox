'use client'
import RootLayout from "@/components/layout/RootLayout"
import Provider from "@/components/theme/Provider"
import Theme from "@/components/theme/Theme"
import { ColorModeScript } from "@chakra-ui/react"
import { Auth0Provider } from "@auth0/auth0-react";

export default function MainLayout({
  children,
}: {
  children: React.ReactNode
}) {
  return (
    <html lang="es">
      {/*
        <head /> will contain the components returned by the nearest parent
        head.tsx. Find out more at https://beta.nextjs.org/docs/api-reference/file-conventions/head
      */}
      <head />
      <body style={{width:'100%'}}>
        <Auth0Provider
        domain="dev-fzybni3fcogdesk7.us.auth0.com"
        clientId="aXSla6nzCklIHesPnRB4In1rgmajnEkK"
        >
        <Provider>
          <ColorModeScript initialColorMode={Theme.config.initialColorMode} />
          <RootLayout>
            {children}
          </RootLayout>
        </Provider>
        </Auth0Provider>
      </body>
    </html >
  )
}
