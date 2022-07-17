import React, { ReactElement } from "react";
import styles from "../../styles/layouts/DefaultLayout.module.css";

export interface DefaultLayoutProps {
  children: ReactElement;
}

const DefaultLayout = ({ children }: DefaultLayoutProps) => {
  return <div className={styles["page-container"]}>{children}</div>;
};

export default DefaultLayout;

export const useDefaultLayout = (page: ReactElement) => (
  <DefaultLayout>{page}</DefaultLayout>
);
