import { ReactElement } from "react"
import styles from "../../styles/utils/PageContainer.module.css";

export interface PageContainerProps {
    children: ReactElement;
}

const PageContainer = ({ children }: PageContainerProps) => {
    return (
        <div className={styles["page-container"]}>{children}</div>
    )
}

export default PageContainer;