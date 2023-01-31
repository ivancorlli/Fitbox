import { Inter } from '@next/font/google'
import Menu from './components/Menu/Menu'

const inter = Inter({ subsets: ['latin'] })

export default function Home() {
  return (
    <div>
      <Menu/>
      <h1>Hello Word</h1>
    </div>
  )
}
