import { ReactElement } from "react"
import styles from "../../styles/utils/ContentBox.module.css"

export interface ContentBoxProps {
  children: ReactElement | string;
}

const ContentBox = ({ children }: ContentBoxProps) => {
  return (
    <div className={styles["content-box"]}>{children}</div>
  )
}

export default ContentBox