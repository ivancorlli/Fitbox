'use client'
import Provider from "@/components/theme/Provider"
import RootLayout from "./RootLayout"

export default function MainLayout({
  children,
}: {
  children: React.ReactNode
}) {
  return (
    <html lang="en">
      {/*
        <head /> will contain the components returned by the nearest parent
        head.tsx. Find out more at https://beta.nextjs.org/docs/api-reference/file-conventions/head
      */}
      <head />
      <body >
        <Provider>
          <RootLayout>{children}</RootLayout>
        </Provider>
      </body>
    </html >
  )
}
