'use client'
import RootLayout from "@/components/layout/RootLayout"
import Provider from "@/components/theme/Provider"
import Theme from "@/components/theme/Theme"
import { ColorModeScript } from "@chakra-ui/react"
import { Session } from "next-auth"
import { SessionProvider } from "next-auth/react"
import { AppProps } from "next/app"

export default function MainLayout({
  children
}: {
  children: React.ReactNode,
}) {
  return (
    <html lang="es">
      {/*
        <head /> will contain the components returned by the nearest parent
        head.tsx. Find out more at https://beta.nextjs.org/docs/api-reference/file-conventions/head
      */}
      <head />
      <body style={{ width: '100%' }}>
        <SessionProvider >
          <Provider>
            <ColorModeScript initialColorMode={Theme.config.initialColorMode} />
            <RootLayout>
              {children}
            </RootLayout>
          </Provider>
        </SessionProvider>
      </body>
    </html >
  )
}
