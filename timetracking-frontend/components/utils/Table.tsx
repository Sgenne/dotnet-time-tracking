import { ReactElement } from "react";
import styles from "../../styles/utils/Table.module.css"


export interface TableProps {
    tableItems: { [key: string]: string | ReactElement }[]
}

const Table = ({ tableItems }: TableProps) => {

    const columns = Object.keys(tableItems[0]);

    const tableHeader = <tr>
        {
            columns.map(
                col => <th key={col}>
                    {col}
                </th>
            )
        }
    </tr>

    const tableRows = tableItems.map((item, itemIndex) => <tr key={itemIndex}>
        {columns.map(col => <td key={itemIndex + col}>{item[col]}</td>)}
    </tr>)


    return (
        <table className={styles["table"]}>
            {tableHeader}
            {tableRows}
        </table>
    )
}



export default Table